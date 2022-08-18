﻿using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Domains.Blog.Comments;
internal class PostCategoryComment:BaseDomain
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostCategoryId { get; set; }
    public PostCategory PostCategory { get; set; }

    public int CommentOwnerId { get; set; }
    public User CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    public PostCategoryComment ReplyToComment { get; set; }
    #endregion
}

internal class PostCategoryCommentEntityConfiguration : IEntityTypeConfiguration<PostCategoryComment>
{
    public void Configure(EntityTypeBuilder<PostCategoryComment> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.CommentText).IsRequired().HasMaxLength(Defaults.LongLength1);

        #endregion

        #region Navigations

        builder.HasOne(e => e.PostCategory).WithMany(e => e.PostCategoryComments).HasForeignKey(e => e.PostCategoryId);
        builder.HasOne(e => e.CommentOwner).WithMany(e => e.PostCategoryComments).HasForeignKey(e => e.CommentOwnerId);
        builder.HasOne(e => e.ReplyToComment).WithOne(e => e.ReplyToComment).HasForeignKey<PostCategoryComment>(x=>x.ReplyToCommentId);
        #endregion
    }
}